namespace TopshelfServiceInstaller
{
    public class InstalacaoConfig
    {
        public const string SERVICE_NAME = "tssi_service_name";
        public const string SERVICE_TITLE = "Topshelf Service Installer Service Title";
        public const string SERVICE_VERSION = "1.0.0";

        public string DiretorioOrigem { get; set; }
        public string DiretorioDestino { get; set; }
        public string NomeServico { get; set; }
        public string TituloServico { get; set; }
        public StatusServico StatusServico { get; set; }
        public string Versao { get; set; }
    }
}
