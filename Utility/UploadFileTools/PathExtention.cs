namespace PC.Utility.UploadFileTools;

public class PathExtention
{
    public static string PatientFile = Path.Combine(Directory.GetCurrentDirectory(), "PatientsFile");

    public static string UserAvatarOriginServer =
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/Image/Users/Avatar/");

    public static string PathImageLicennsePsychologist =
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/Image/Psychology/Licennse/");
}