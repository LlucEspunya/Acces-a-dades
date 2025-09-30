# APUNTS

##   Crear Docker

```bash
    Creació contenidor
    docker run --name nombre_docker -e POSTREGRES_PASSWORD=Patata123 -d postgres

    Veure imatges
    docker image ls

    Docker stop nombre_docker

    Visualitzar dockers
    docker ps -a 

    Visualitzar dockers actius
    docker ps

    Creació MSSQL
    docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Patata123" --name nombre_docker -d mcr.microsoft.com/mssql/server:2025-latest

 ```
## Crear aplicació
```bash
    dotnet new console -n ADO #nom aplicació
```
## Accés i execució aplicació
```bash
    cd ADO  #ubicació aplicació
    dotnet run
```

## Connectar base de dades

```bash
    La connexió a BD és molt costos, es fa un pool de connexions (.net)
    SQLConnection (classe) per establir una connexió (crea un objecte)
```

```CSharp
    SqlConnection c1 = new SqlConnection();

    //csproj
    //ItemGroup
```
