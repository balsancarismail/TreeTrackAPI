using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TreeTrackAPI.DataAccessLayer.abstracts;
using TreeTrackAPI.Domain.concretes;
using TreeTrackAPI.Domain.dtos.gardenDtos;
using TreeTrackAPI.Domain.dtos.noteDtos;
using TreeTrackAPI.Services.utilities.formatUtilities;

namespace TreeTrackAPI.Services.concretes
{
    public class GardenService
    {
        private readonly IGardenDal gardenDal;
        private readonly UserService userService;
        private readonly IMapper mapper;

        public GardenService(IGardenDal gardenDal, IMapper mapper, UserService userService)
        {
            this.gardenDal = gardenDal;
            this.mapper = mapper;
            this.userService = userService;
        }

        public async Task<GetGardenDto> saveGarden(SaveGardenDto saveGardenDto, int userId)
        {
            var garden = mapper.Map<Garden>(saveGardenDto);
            var getUserDto = userService.getUserById(userId);
            var user = mapper.Map<User>(getUserDto);

            garden.Users = new List<User> { user };

            var savedGarden = await this.gardenDal.CreateAsync(garden);
            if (savedGarden == null) { throw new Exception("Garden could not be created"); }

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

            throw new Exception("Garden could not be created");
        }

        public async Task<List<GetGardenDto>> getGardens()
        {
            var gardens = await gardenDal.GetAllAsync();
            var getGardenDtos = mapper.Map<List<GetGardenDto>>(gardens);

            return getGardenDtos;
        }

        public async Task<GetGardenDto> getGardenById(int id)
        {
            var garden = await gardenDal.GetByFilterAsync(g => g.Id == id);

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
            var updatedGarden = gardenDal.Update(garden);

            if (updatedGarden == null) throw new Exception("Photo could not be added!");

            var getNoteDto = mapper.Map<GetNoteDto>(note);
            return getNoteDto;
        }
    }
}
