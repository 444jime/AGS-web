using AGS_models;
using AGS_services.Repositories;

namespace AGS_services
{
    public class CarouselService : ICarouselService
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly iCarouselRepository _carouselRepository;

        public CarouselService(IFileStorageService fileStorageService, iCarouselRepository carouselRepository)
        {
            _fileStorageService = fileStorageService;
            _carouselRepository = carouselRepository;
        }

        public async Task<Carrusel> AddImageToCarouselAsync(IFormFile file, string? title, int sortOrder)
        {
            string imageUrl = await _fileStorageService.UploadFileAsync(file);

            var newImage = new Carrusel
            {
                Url = imageUrl,
                Nombre = title,
                Orden = sortOrder
            };

            return await _carouselRepository.AddAsync(newImage);
        }

        public async Task<IEnumerable<Carrusel>> GetImages()
        {
            return await _carouselRepository.GetAllAsync();
        }
    }
}