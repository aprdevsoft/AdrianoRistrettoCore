namespace AdrianoRistrettoCore.Repository
{
    public class DataBaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ContratosCollectionName { get; set; } = null!;
        public string EmpresasCollectionName { get; set; } = null!;
        public string FuncionariosCollectionName { get; set; } = null!;
        
    }
}
