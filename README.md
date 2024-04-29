# WeatherApp

## Overview
WeatherApp is a web application that provides the current weather for any zip code in the United States. It utilizes two APIs to gather data:

- [Zippopotamus API](https://api.zippopotam.us/): This API is used to retrieve city, state, latitude, and longitude information for a given zip code.
- [Open-Meteo API](https://github.com/open-meteo/open-meteo): This API is used to fetch current weather details.

## Disclaimer
Please note that the images and icons used on the weather page are provided by Apple. They are not owned or created by WeatherApp. You can learn more about these icons on [Apple's support page](https://support.apple.com/guide/iphone/learn-the-weather-icons-iph4305794fb/ios).

# Docker command setup:
Make sure to run these commands while you are currently in the WeatherAppRepo directory because the dockerfile lives there.
# Build the Docker image
```bash docker build --rm -t productive-dev/weather-app:latest . ```

# List Docker images and filter by name
```bash docker image ls | grep weather-app ```

# Run the Docker container
```bash docker run --rm -p 5000:5000 -p 5001:5001 -e ASPNETCORE_HTTP_PORT=https://+:5001 -e ASPNETCORE_URLS=http://+:5000 productive-dev/weather-app ```
