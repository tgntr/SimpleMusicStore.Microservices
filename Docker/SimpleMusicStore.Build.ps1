cd "..\"

## General variables ##
$simpleMusicStoreProjectsFullRootPath = get-location

$webApiProjectFileFullPath = join-path $simpleMusicStoreProjectsFullRootPath ".\SimpleMusicStore\SimpleMusicStore.Api\SimpleMusicStore.Api.csproj"
$webApiBuildFullPath = join-path $simpleMusicStoreProjectsFullRootPath "\Docker\api\bin"

$microservicesFullRootPath = join-path $simpleMusicStoreProjectsFullRootPath ".\SimpleMusicStore\SimpleMusicStore.Microservices"
$microservicesBuildGeneralFullPath = join-path $simpleMusicStoreProjectsFullRootPath "\Docker\ms"

$dockerComposeFileFullPath = join-path $simpleMusicStoreProjectsFullRootPath "\Docker\"

## Public WebApi Build ##
dotnet publish $webApiProjectFileFullPath --self-contained -r linux-x64 -o $webApiBuildFullPath

## Microservices Build ##
$microserviceProjects = Get-ChildItem -Path ($microservicesFullRootPath) -Exclude Models

foreach ($currentProject in $microserviceProjects)
{
	$currentMicroserviceProjectFileFullPath = $microservicesFullRootPath + "\" + $currentProject.Name + "\" + $currentProject.Name + ".csproj"
	$currentMicroserviceBuildFullPath = $microservicesBuildGeneralFullPath + "\" + $currentProject.Name + "\bin"

	dotnet publish $currentMicroserviceProjectFileFullPath --self-contained -r linux-x64 -o $currentMicroserviceBuildFullPath
}

cd $dockerComposeFileFullPath
docker-compose down -v
docker-compose up --build -d