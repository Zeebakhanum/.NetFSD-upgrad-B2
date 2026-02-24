// Weather Data Fetcher (LEVEL-2)

// API URL (Bangalore coordinates example)
const API_URL =
  "https://api.open-meteo.com/v1/forecast?latitude=12.97&longitude=77.59&current_weather=true";

// --------------------------------------------
// VERSION 1: Using Promises (.then)
// --------------------------------------------

const fetchWeatherWithPromises = () => {
  fetch(API_URL)
    .then((response) => {
      if (!response.ok) {
        throw new Error("Failed to fetch weather data");
      }
      return response.json();
    })
    .then((data) => {
      const weather = data.current_weather;

      console.log(`
🌤 Weather Report (Promises)
-----------------------------
Temperature: ${weather.temperature}°C
Wind Speed: ${weather.windspeed} km/h
Time: ${weather.time}
`);
    })
    .catch((error) => {
      console.error("❌ Error (Promises):", error.message);
    });
};

// --------------------------------------------
// VERSION 2: Using async/await
// --------------------------------------------

const fetchWeatherAsync = async () => {
  try {
    const response = await fetch(API_URL);

    if (!response.ok) {
      throw new Error("Failed to fetch weather data");
    }

    const data = await response.json();
    const weather = data.current_weather;

    console.log(`
🌦 Weather Report (Async/Await)
--------------------------------
Temperature: ${weather.temperature}°C
Wind Speed: ${weather.windspeed} km/h
Time: ${weather.time}
`);
  } catch (error) {
    console.error("❌ Error (Async/Await):", error.message);
  }
};

// Call both versions
fetchWeatherWithPromises();
fetchWeatherAsync();