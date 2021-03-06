﻿namespace TopshelfServiceInstaller
{
    public class InstalacaoConfig
    {
        public const string SERVICE_NAME = "TopshelfServiceSample";
        public const string SERVICE_EXE = "TopshelfServiceSample.exe";
        public const string SERVICE_TITLE = "Topshelf Service Sample";
        public const string SERVICE_VERSION = "1.0.0";

        public string DiretorioOrigem { get; set; }
        public string DiretorioDestino { get; set; }
        public string NomeServico { get; set; }
        public string TituloServico { get; set; }
        public StatusServico StatusServico { get; set; }
        public string Versao { get; set; }
    }
}
