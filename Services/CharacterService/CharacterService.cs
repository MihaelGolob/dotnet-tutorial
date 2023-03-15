namespace dotnet_tutorial.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character {Id = 1, Name = "Sam"},
            new Character {Id = 2, Name = "Gandalf"},
            new Character {Id = 3, Name = "Legolas"}
        };

        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper) {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);

            return new ServiceResponse<List<GetCharacterDto>> {
                Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList()
            };
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            return new ServiceResponse<List<GetCharacterDto>> {
                Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList()
            };
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var result = characters.FirstOrDefault(c => c.Id == id);
            return new ServiceResponse<GetCharacterDto> {
                Data = _mapper.Map<GetCharacterDto>(result)
            };
        }
    }
}