cd "..\"

## General variables ##
$bcProjectFullRootPath = get-location

$webApiProjectFileFullPath = join-path $bcProjectFullRootPath ".\SimpleMusicStore\SimpleMusicStore.Api\SimpleMusicStore.Api.csproj"
$webApiBuildFullPath = join-path $bcProjectFullRootPath "\Docker\api\bin"

$microservicesFullRootPath = join-path $bcProjectFullRootPath ".\SimpleMusicStore\SimpleMusicStore.Microservices"
$microservicesBuildGeneralFullPath = join-path $bcProjectFullRootPath "\Docker\ms"

$dockerComposeFileFullPath = join-path $bcProjectFullRootPath "\Docker\"

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