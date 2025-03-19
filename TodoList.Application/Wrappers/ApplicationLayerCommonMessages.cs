namespace TodoList.Application.Wrappers;

public static class ApplicationLayerCommonMessages
{
    public static class Database
    {
        public static readonly Error DuplicateTitle = Error.Exception("400", "این عنوان قبلا انتخاب شده است.");
        public static readonly Error Failed = Error.Exception("500", "خطا سمت سرور.");
        public static readonly Error NotFount = Error.Exception("404", "عنوانی با پارامتر های وارد شده یافت نشد.");
    }
}
