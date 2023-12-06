namespace Utility.Validation;

public class ValidationMessage
{
    public const string Vacant = "مقداری در بانک یافت نشد";
    public const string SuccessCreate = "عملیات ثبت با موفقیت انجام شد";
    public const string SuccessDelete = "عملیات حذف با موفقیت انجام شد";
    public const string SuccessUpdate = "عملیات ویرایش با موفقیت انجام شد";
    public const string NoFoundGet = "فیلدی با این مشخصه یافت نشد";
    public const string RecordNotFound = "رکورد با اطلاعات درخواست شده یافت نشد.";
    public const string SuccessGet = "فیلدی با کد منحصر به فرد یافت شد";
    public const string SuccessGetAll = "تمامی مقادیر به خوبی واکشی شدند";
    public const string DuplicatedRecord = "امکان ثبت رکورد تکراری وجود ندارد";
    public const string SuccessActive = "فیلد فعال شد";
    public const string SuccessActiveFile = "از این پس این فایل قابل نمایش است";
    public const string SuccessDeActiveFile = "از این پس این فایل قابل نمایش نیست";
    public const string SuccessDeActive = "فیلد با موفقیت غیر فعال شد";
    public const string IsRequired = "مقادیر برخی از فیلد ها خالی است.";
    public const string InvalidFileFormat = "فرمت فایل مجاز نیست";
    public const string SuccessActivePhone = "شماره تلفن فعال شد";
    public const string PasswordLenght = "طول کلمه عبور انتخابی کمتر از 5 کاراکتر می باشد";
    public const string SuccessUpdatePassword = "رمز عبور شما با موفقیت تغییر کرد";
    public const string NoConfirmPassword = "تکرار رمز عبور با رمز عبور جدید مشابه نیست";
    public const string WrongPassword = "رمز عبور اشتباه است";
    public const string SuccessLogin = "شما با موفقیت به حساب کاربری وارد شدید";
    public const string AccountIsBlock = "حساب کاربری شما غیر فعال است";
    public const string SuccessRegister = "حساب کاربری با موفقیت ساخته شد";
    public const string PasswordsNotMatch = "پسورد و تکرار آن با هم مطابقت ندارند";
    public const string ActivePhone = "شماره موبایل شما اعتبار سنجی نشده";
    public const string DuplicatedRecordLicennseCode = "کد پروانه پزشکی تکراری است";
    public const string DuplicatedRecordDiscountPatient = "نمی توان برای یک بیمار از دوتا تخفیف استفاده کرد";
    public const string RecordNotFoundSectionQuestionErrorTest = "مشخص کنید که این سوالات مربوط به کدام آزمون هستند";
    public const string RecordNotFoundSectionAnswerErrorQuestion = "مشخص کنید که این جواب ها مربوط به کدام سوال است";
    public const string SuccessChangeAuth = "سطح دسترسی کاربر با موفقیت تغییر کرد!";
    public const string SuccessCheckUserBeforeChangeAuth = "کاربر اعتبار سنجی و تایید می شود!";
    public const string SuccessIsCheckedSectionPsychologist = "کاربر تایید شده و اماده تبدیل نقش است";
    public const string SuccessFindPatientSectionPsychologist = "متاسفانه این کاربر بیمار است و نمی توان ان را روانشناس کرد";
    public const string IsRequiredSearch = "هیچ فیلدی برای جستجو پیدا نشد";
    public const string SuccessVisited = "بیمار ویزیت شد!";
    public const string SuccessCanseled = "ویزیت بیمار لغو شد";
    public const string RecordDelete = "این فیلد حذف شده";

    public const string Blocked = "کاربر بلاک شد";
    public const string OnBlocked = "حساب فعال شد";


    public static string SuccessGetAllSearch(int count)
    {
        return $"تعداد {count} عدد فیلد با این اطلاعات یافت شد";
    }

    public static string ErrorCreate(string e)
    {
        return $"مشکلی در افزودن این فیلد روخ داده. متن اررور:({e})";
    }

    public static string ErrorUpdate(string e)
    {
        return $"مشکلی در ویرایش این فیلد روخ داده. متن اررور:({e})";
    }

    public static string ErrorDelete(string e)
    {
        return $"مشکلی در حذف این فیلد روخ داده. متن اررور:({e})";
    }

    public static string ErrorGetAll(string e)
    {
        return $"مشکلی در واکشی فیلد ها روخ داده. متن اررور:({e})";
    }

    public static string ErrorGet(string e)
    {
        return $"مشکلی در واکشی فیلد روخ داده. متن اررور:({e})";
    }

    public static string ErrorLogin(string e)
    {
        return $"مشکلی در وارد شدن به حساب کاربری روخ داده. متن اررور:({e})";
    }

    public static string ErrorChackUserInChangeAuth(string e)
    {
        return $"در هنگام تایید کاربر برای تغییر سطح دسترسی ان به مشکل برخوردیم. متن اررور:({e})";
    }

    public static string ErrorChangeAuth(string e)
    {
        return $"در هنگام تغییر سطح دسترسی کاربر به مشکل برخوردیم. متن اررور:({e})";
    }

    public static string AdminSuccessUpdatePassword(string fn, string g)
    {
        return $"رمز {g} {fn} با موقیت تغییر یافت";
    }

    public static string ErrorCanseled(string e)
    {
        return $"در زمان لغو کردن ویزیت بیمار به مشکل برخوردیم. متن اررور:({e})";
    }

    public static string ErrorVisited(string e)
    {
        return $"در زمان تایید کردن ویزیت بیمار به مشکل برخوردیم. متن اررور:({e})";
    }
}