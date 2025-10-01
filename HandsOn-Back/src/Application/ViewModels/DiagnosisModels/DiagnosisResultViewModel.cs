using Core.Entities;
using Application.ViewModels.DiseaseModels;
namespace Application.ViewModels.DiagnosisModels
{
    public class DiagnosisResultViewModel
    {
        public List<ImageSimilarityViewModel> ImageSimilarities { get; set; } = new List<ImageSimilarityViewModel>();

        public static DiagnosisResultViewModel FromEntity(DiagnosisResult diagnosisResult)
        {
            return new DiagnosisResultViewModel
            {
                ImageSimilarities = diagnosisResult.Similarities
                    .Select(ImageSimilarityViewModel.FromEntity).ToList()
            };
        }
    }

    public class ImageSimilarityViewModel
    {
        public string ImageBook { get; set; } = string.Empty;
        public double Similarity { get; set; }
        public DiseaseViewModel? Disease { get; set; }

        public static ImageSimilarityViewModel FromEntity(ImageSimilarity imageSimilarity)
        {
            return new ImageSimilarityViewModel
            {
                ImageBook = imageSimilarity.ImageBook,
                Similarity = imageSimilarity.Similarity,
                Disease = imageSimilarity.Disease != null ? DiseaseViewModel.FromEntity(imageSimilarity.Disease) : null
            };
        }
    }
}