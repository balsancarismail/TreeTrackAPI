using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using TreeTrackAPI.DataAccessLayer.abstracts;
using TreeTrackAPI.Domain.concretes;
using TreeTrackAPI.Domain.dtos.gardenDtos;
using TreeTrackAPI.Domain.dtos.noteDtos;
using TreeTrackAPI.Domain.helpers;
using TreeTrackAPI.Services.utilities.formatUtilities;

namespace TreeTrackAPI.Services.concretes
{
    public class GardenService
    {
        private readonly IGardenDal gardenDal;
        private readonly IUserGardenDal userGardenDal;
        private readonly UserService userService;
        private readonly IMapper mapper;

        public GardenService(IGardenDal gardenDal, IMapper mapper, UserService userService, IUserGardenDal userGardenDal)
        {
            this.gardenDal = gardenDal;
            this.mapper = mapper;
            this.userService = userService;
            this.userGardenDal = userGardenDal;
        }

        public async Task<GetGardenDto> saveGarden(SaveGardenDto saveGardenDto)
        {
            Polygon polygon = GeographyHelper.ConvertListToPolygon(saveGardenDto.Polygon);
            var garden = mapper.Map<Garden>(saveGardenDto);
            var savedGarden = await this.gardenDal.CreateAsync(garden);
            if (savedGarden == null) { throw new Exception("Garden could not be created"); }

            // Insert relation to UserGarden
            foreach (var userId in saveGardenDto.UserIds)
            {
                var userGarden = new UserGarden()
                {
                    GardenId = savedGarden.Id,
                    UserId = userId
                };
                await this.userGardenDal.CreateAsync(userGarden);

            }
            var getGarden = mapper.Map<GetGardenDto>(saveGardenDto);
            return getGarden;
        }

        public GetGardenDto updateGarden(UpdateGardenDto updateGardenDto)
        {
            var garden = mapper.Map<Garden>(updateGardenDto);
            var result = gardenDal.Update(garden);

            if (result != null)
            {
                var getGardenDto = mapper.Map<GetGardenDto>(result);
                return getGardenDto;
            }

            throw new Exception("Garden could not be updated");
        }

        public async Task<List<GetGardenDto>> getGardens()
        {
            var gardens = gardenDal.GetAllGardenInfo();
            var getGardenDtos = mapper.Map<List<GetGardenDto>>(gardens);

            return getGardenDtos;
        }

        public async Task<GetGardenDto> getGardenById(int id)
        {
            var garden = await gardenDal.GetAllGardenInfoById(id);

            if (garden == null)
                throw new Exception("Garden not found!");


            var getGardenDto = mapper.Map<GetGardenDto>(garden);
            return getGardenDto;
        }

        public GetNoteDto addNote(SaveNoteDto saveNoteDto, int gardenId)
        {
            var garden = gardenDal.GetAll().Include(g => g.Notes).Where(g => g.Id == gardenId).FirstOrDefault();
            var note = mapper.Map<Note>(saveNoteDto);
            if (saveNoteDto.ImageFile != null)
                note.Image = saveNoteDto.ImageFile.convertToByteArray();

            var gardenNotes = garden.Notes ?? new List<Note> { note };
            garden.Notes = gardenNotes;
            var updatedGarden = gardenDal.Update(garden);

            if (updatedGarden == null) throw new Exception("Note could not be added!");

            var getNoteDto = mapper.Map<GetNoteDto>(note);
            return getNoteDto;
        }
    }
}
