namespace ApiPreferencia.VIewModel.UserVM
{
    public class PaginacaoUserViewModel
    {
        public IEnumerable<GetUserViewModel>? User { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => User?.Count() < PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Users?pagina={CurrentPage - 1}&tamanho={PageSize}" : string.Empty;
        public string NextPageUrl => HasNextPage ? $"/Users?pagina={CurrentPage + 1}&tamanho={PageSize}" : string.Empty;

    }
}
