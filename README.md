# VehicleTestProject

This application is used for creating, viewing or editing information about vehicle makes and models. To access the administration area use e-mail: admin@admin.com and Password: Password12345

Migration assembly is in Project.Service layer, so when applying migrations use tag -Project (--project [-p] in .CLI) and name of project Project.Service (.\Project.Service\Project.Service.csproj) and make sure to set default project to Project.MVC or use tag -StartupProject (--startup-project [-s] in .CLI) and name of startup project Project.MVC (.\Project.MVC.csproj).
