using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TodoList.Application;

public static class ApplicationLayerCommonMessages
{
    public static class Database
    {
        public static readonly string DuplicateTitle = "این عنوان قبلا انتخاب شده است.";
        public static readonly string Failed = "خطا سمت سرور.";
        public static readonly string NotFount = "عنوانی با پارامتر های وارد شده یافت نشد.";
    }

    public static class TaskValidator
    {
        public static readonly string TitleIsRequired = "عنوان اجباری است";
        public static readonly string DescriptionIsRequired = "توضیحات وظیفه اجباری است";
        public static readonly string DueDateIsRequired = "تاریخ مهلت اتمام وظیفه اجباری است.";
        public static readonly string IsCompletedIsRequired = "وضعیت اتمام وظیفه اجباری است.";
        public static readonly string DescriptionMustBeLessThan1000Characters = "توضیحات وظیفه نمیتئاند بیش از 1000 کارکتر داشته باشد";
        public static readonly string TitleMustBeLessThan100Characters = "عنوان وظیفه نمیتئاند بیش از 100 کارکتر داشته باشد";
    }
}
