FROM mcr.microsoft.com/dotnet/framework/runtime:4.8-windowsservercore-ltsc2019


WORKDIR /app
EXPOSE 80



COPY /bin/Debug .
ENTRYPOINT ["HttpClientSample.exe"]