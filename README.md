# GeoFinder

GeoFinder is a simple command-line tool written in C# that allows you to find the geographical location of an IP address and visualize it on Google Maps.

## Features

- **Find Location**: Enter an IP address and retrieve its geographical details including city, region, country, postal code, and timezone.
- **Google Maps Integration**: Automatically open Google Maps in your default web browser to visualize the location based on the coordinates obtained from the IP address.
- **Continuous Search**: Keep searching for location details by entering multiple IP addresses without restarting the program.

## Installation

1. Clone or download the project repository.
2. Open the solution file (`geofinder.sln`) in Visual Studio or your preferred C# IDE.
3. Build the solution to compile the project. You can select the "Console App (.NET Framework)" template
4. Run the `geofinder` executable or start the program from within your IDE.

## Usage

1. Run the program.
2. When prompted, enter the IP address you want to locate.
3. The program will display the geographical details of the IP address including city, region, country, postal code, and timezone.
4. It will also automatically open Google Maps in your default web browser to visualize the location on the map.
5. To search for another IP address, simply enter a new IP address when prompted. Type `exit` to quit the program.

## Dependencies

- Newtonsoft.Json: For parsing JSON responses from the IP address lookup API.
- System.Net.Http: For making HTTP requests to the IP address lookup API.
- System.Diagnostics: For launching the default web browser to open Google Maps.

## Contributing

Contributions to GeoFinder are welcome! If you find any bugs or have suggestions for improvements, please open an issue or submit a pull request.
