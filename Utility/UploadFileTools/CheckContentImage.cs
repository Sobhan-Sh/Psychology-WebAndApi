using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Utility.UploadFileTools;
public static class CheckContentImage
{
    public const int ImageMinimumBytes = 512;
    public static bool IsCheckFile(this IFormFile postedFile)
    {

        string[] allowedImageTypes = { "image/jpg", "image/jpeg", "image/pjpeg", "image/x-png", "image/png" };
        string[] allowedVideoTypes = { "video/mp4", "video/mpeg", "video/quicktime" };
        string[] allowedAudioTypes = { "audio/mpeg", "audio/wav", "audio/ogg" };
        string[] allowedDocumentTypes = { "application/pdf" };
        string[] allowedPowerpointTypes = { "application/vnd.ms-powerpoint", "application/vnd.openxmlformats-officedocument.presentationml.presentation" };

        //-------------------------------------------
        //  Check the file mime types
        //-------------------------------------------
        if (allowedImageTypes.Contains(postedFile.ContentType.ToLower()) ||
            allowedVideoTypes.Contains(postedFile.ContentType.ToLower()) ||
            allowedAudioTypes.Contains(postedFile.ContentType.ToLower()) ||
            allowedDocumentTypes.Contains(postedFile.ContentType.ToLower()) ||
            allowedPowerpointTypes.Contains(postedFile.ContentType.ToLower()))
        {
            return true;
        }

        //-------------------------------------------
        //  Check the file extension
        //-------------------------------------------
        string fileExtension = Path.GetExtension(postedFile.FileName).ToLower();
        if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" ||
            fileExtension == ".mp4" || fileExtension == ".mpeg" || fileExtension == ".mov" ||
            fileExtension == ".mp3" || fileExtension == ".wav" || fileExtension == ".ogg" ||
            fileExtension == ".pdf" ||
            fileExtension == ".ppt" || fileExtension == ".pptx")
        {
            return true;
        }

        //-------------------------------------------
        //  Attempt to read the file and check the first bytes
        //-------------------------------------------
        try
        {
            if (!postedFile.OpenReadStream().CanRead)
            {
                return false;
            }
            //------------------------------------------
            //check whether the image size exceeding the limit or not
            //------------------------------------------ 
            if (postedFile.Length < ImageMinimumBytes)
            {
                return false;
            }

            byte[] buffer = new byte[ImageMinimumBytes];
            postedFile.OpenReadStream().Read(buffer, 0, ImageMinimumBytes);
            string content = System.Text.Encoding.UTF8.GetString(buffer);
            if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }

        //-------------------------------------------
        //  Try to instantiate new Bitmap, if .NET will throw exception
        //  we can assume that it's not a valid image
        //-------------------------------------------

        try
        {
            using (var bitmap = new Bitmap(postedFile.OpenReadStream()))
            {
            }
        }
        catch (Exception)
        {
            return false;
        }
        finally
        {
            postedFile.OpenReadStream().Position = 0;
        }

        return true;
    }
}