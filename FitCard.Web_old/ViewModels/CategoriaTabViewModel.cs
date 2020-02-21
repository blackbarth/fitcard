namespace FitCard.Web.ViewModels
{
    public class CategoriaTabViewModel
    {
        public Tab ActiveTab { get; set; }
    }

    public enum Tab
    {
        Todos,
        Novo
    }
}