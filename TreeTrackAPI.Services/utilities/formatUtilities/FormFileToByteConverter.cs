using Microsoft.AspNetCore.Http;

namespace TreeTrackAPI.Services.utilities.formatUtilities
{
    public static class FormFileToByteConverter
    {
        public static byte[] convertToByteArray(this IFormFile formFile)
        {
            if (formFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    formFile.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    return fileBytes;
                }
            }
            return null;
        }
    }
}
