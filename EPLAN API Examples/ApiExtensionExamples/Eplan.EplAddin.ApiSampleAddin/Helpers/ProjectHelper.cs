using Eplan.EplApi.DataModel;
using Eplan.EplApi.HEServices;
using System;
using System.Linq;

namespace Eplan.EplAddin.ApiSampleAddin.Helpers
{
    public static class ProjectHelper
    {
        public static Project GetCurrentProject()
        {
            try
            {
                SelectionSet selection = new SelectionSet();
                Project project = selection.SelectedProjects.FirstOrDefault();

                if (project == null)
                    throw new Exception("No Selected Project!");

                return project;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Project GetProject(string elkFullPath)
        {
            #region Parameter Validation

            if (string.IsNullOrWhiteSpace(elkFullPath))
                throw new ArgumentNullException("elkFullPath");

            #endregion

            using (ProjectManager manager = new ProjectManager())
            {
                return manager.GetProject(elkFullPath);
            }
        }
    }
}
