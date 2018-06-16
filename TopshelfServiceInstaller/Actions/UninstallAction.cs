using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TopshelfServiceInstaller.Actions
{
    public class UninstallAction
    {
        private readonly InstalacaoConfig _config;
        private readonly MainWizardForm _form;

        public static void DoAction(InstalacaoConfig config, MainWizardForm form)
        {
            new UninstallAction(config, form).DoAction();
        }

        private UninstallAction(InstalacaoConfig config, MainWizardForm form)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            if (form == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            _config = config;
            _form = form;
        }

        public void DoAction()
        {
            var listaExcluir = EnumerarArquivosParaExcluir(new DirectoryInfo(_config.Diretorio));

            foreach (var excluir in listaExcluir)
            {
                Debug.WriteLine(excluir.Path);

                if (excluir.IsDirectory)
                {
                    Directory.Delete(excluir.Path);
                }
                else
                {
                    File.Delete(excluir.Path);
                }
            }
        }

        private IList<UninstallFileInfo> EnumerarArquivosParaExcluir(DirectoryInfo dirRoot)
        {
            var lista = new List<UninstallFileInfo>();

            foreach (FileInfo file in dirRoot.GetFiles())
            {
                lista.Add(new UninstallFileInfo { Path = file.FullName, IsDirectory = false });
            }

            foreach (DirectoryInfo dir in dirRoot.GetDirectories())
            {
                lista.AddRange(EnumerarArquivosParaExcluir(new DirectoryInfo(dir.FullName)));
                lista.Add(new UninstallFileInfo { Path = dir.FullName, IsDirectory = true });
            }

            return lista.ToArray();
        }
    }
}
