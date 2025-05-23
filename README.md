Weather Data Collection API :

	This is a service that calls a Web API Endpoint : https://api.openweathermap.org/ and Service Context : data/2.5/weather and takes the City and APIKey as parameters. In response, it gets the weather data for the respective City.

End Goal : The end goal is to take a list of cities from the user on a file and then present an output file that provides all the Weather data for all the Cities (from the input file) for a given date. It should also keep all the historical data by using the date as the naming convention for all the output files.

Implementation : We created an ASP .Net Core Web API using .net 8.0 that has a controller called Weather Controller that takes the input file that has all the Cities and then loops through the city list and in every iteration, it calls the API and then append the Weather Data on the output file that gets the name as per the date when this service runs.

We take the City-list file in the Input Folder and Present the Weather Files in the Output folder.
In case if we run the API multiple times in a day, The output folder retains the last run file for that day and removes the previous files from the previous runs for that particular day.
