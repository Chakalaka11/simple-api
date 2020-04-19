# Get latest runtime version iamge
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic
RUN mkdir /home/netapp
WORKDIR /home/netapp
COPY bin/Release/netcoreapp3.1 .
EXPOSE 5050
CMD dotnet ProductApi.dll