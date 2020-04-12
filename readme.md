# Simple Api (experiments with docker and docker-compose)
This API has just several standart controllers and methods for simpified tests of created containers

TODO:
- [x] Create image and run with "docker" commands
- [ ] Create image and run with "docker-compose" commands

## Commands for Docker
- First of all - you need to make a release version of the app, for this purpose run `dotnet publish -c Release`
- After that you could validate release by running `dotnet bin/Release/netcoreapp3.1/Hello-world.dll`
- When runtime is validated, simply run `docker build -t netimg:0.3 .`
  - `-t` is name:tag of image
  - `.` is directory
- Execute `docker image ls` for validating that image is created
- Execute `sudo docker container run --publish 5050:5050 --detach --name netcon netimg:0.3` to make a magick
  - `--publish` is in format `local-port:container-port`
  - `--detach` need to run on background because Docker will automatically make it look up
  - `--name` self-explanatory
- Execute `docker container stop netcon` to stop container
- For remove we have `container rm` and `image rm`