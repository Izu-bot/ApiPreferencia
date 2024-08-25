using ApiPreferencia.VIewModel.UserVM;

namespace ApiPreferencia.VIewModel.LabelVM
{
    public class PaginacaoLabelViewModel
    {
        public IEnumerable<GetLabelViewModel>? Label { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Label?.Count() < PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Label?pagina={CurrentPage - 1}&tamanho={PageSize}" : string.Empty;
        public string NextPageUrl => HasNextPage ? $"/Label?pagina={CurrentPage + 1}&tamanho={PageSize}" : string.Empty;
    }
}
