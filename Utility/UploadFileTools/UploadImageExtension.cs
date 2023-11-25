using Microsoft.AspNetCore.Http;

namespace Utility.UploadFileTools;

public static class UploadImageExtension
{
    public static bool AddFileToServer(this IFormFile image, string fileName, string orginalPath, int? width,
        int? height, string thumbPath = null, string deletefileName = null)
    {
        if (image != null && image.IsCheckFile())
        {
            if (!Directory.Exists(orginalPath))
                Directory.CreateDirectory(orginalPath);
            if (!string.IsNullOrEmpty(deletefileName))
            {
                if (File.Exists(orginalPath + deletefileName))
                    File.Delete(orginalPath + deletefileName);
                if (!string.IsNullOrEmpty(thumbPath))
                    if (File.Exists(thumbPath + deletefileName))
                        File.Delete(thumbPath + deletefileName);
            }

            var OriginPath = orginalPath + fileName;
            using (var stream = new FileStream(OriginPath, FileMode.Create))
            {
                if (!Directory.Exists(OriginPath)) image.CopyTo(stream);
            }

            if (!string.IsNullOrEmpty(thumbPath))
            {
                if (!Directory.Exists(thumbPath))
                    Directory.CreateDirectory(thumbPath);
                var resizer = new ImageOptimizer();

                if (width != null && height != null)
                    resizer.ImageResizer(orginalPath + fileName, thumbPath + fileName, width, height);
            }

            return true;
        }

        return false;
    }

    public static void DeleteImage(this string fileName, string OriginPath, string ThumbPath)
    {
        if (!string.IsNullOrEmpty(fileName))
        {
            if (File.Exists(OriginPath + fileName))
                File.Delete(OriginPath + fileName);

            if (!string.IsNullOrEmpty(ThumbPath))
                if (File.Exists(ThumbPath + fileName))
                    File.Delete(ThumbPath + fileName);
        }
    }
}