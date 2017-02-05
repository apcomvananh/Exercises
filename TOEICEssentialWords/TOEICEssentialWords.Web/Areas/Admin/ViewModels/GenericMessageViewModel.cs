namespace TOEICEssentialWords.Web.Areas.Admin.ViewModels
{
    public enum GenericMessages
    {
        warning,
        danger,
        success,
        info
    }

    public class GenericMessageViewModel
    {
        public GenericMessageViewModel()
        {
            MessageType = GenericMessages.info;
        }

        public string Message { get; set; }

        public GenericMessages MessageType { get; set; }

        public bool ConstantMessage { get; set; }
    }
}