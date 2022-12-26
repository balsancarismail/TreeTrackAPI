using AutoMapper;
using TreeTrackAPI.DataAccessLayer.abstracts;
using TreeTrackAPI.Domain.concretes;
using TreeTrackAPI.Domain.dtos.userDtos;

namespace TreeTrackAPI.Services.concretes
{
    public class UserService
    {
        private readonly IUserDal userDal;
        private readonly IMapper mapper;

        public UserService(IUserDal userDal, IMapper mapper)
        {
            this.userDal = userDal;
            this.mapper = mapper;
        }

        public async Task<GetUserDto> saveUser(SaveUserDto saveUserDto)
        {
            var user = mapper.Map<User>(saveUserDto);
            var result = await userDal.CreateAsync(user);

            if (result != null)
            {
                var getUserDto = mapper.Map<GetUserDto>(result);
                return getUserDto;
            }

            throw new Exception("User could not be created");
        }

        public GetUserDto updateUser(UpdateUserDto updateUserDto)
        {
            var user = mapper.Map<User>(updateUserDto);
            var result = userDal.Update(user);

            if (result != null)
            {
                var getUserDto = mapper.Map<GetUserDto>(result);
                return getUserDto;
            }

            throw new Exception("User could not be created");
        }

        public async Task<List<GetUserDto>> getUsers()
        {
            var users = await userDal.GetAllAsync();
            var getUserDtos = mapper.Map<List<GetUserDto>>(users);

            return getUserDtos;
        }

        public async Task<GetUserDto> getUserById(int id)
        {
            var user = await userDal.GetByFilterAsync(u => u.Id == id);

            if (user == null)
                throw new Exception("User not found!");


            var getUserDto = mapper.Map<GetUserDto>(user);
            return getUserDto;
        }

    }
}
