# Finland Resort

A modern ASP.NET Core 8 MVC website for [finland-resort.com](https://finland-resort.com) — Finland's premier casino hotels.

## Features

- **Home** — Hero section, featured casino hotels, amenities overview
- **About Us** — Company story, mission, values
- **Contact Us** — Contact form with validation
- **Privacy Policy** — GDPR-compliant privacy policy

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Run Locally

```bash
cd FinlandCasinoHotels
dotnet run
```

Open [http://localhost:5000](http://localhost:5000) in your browser.

## Project Structure

```
FinlandCasinoHotels/
├── Controllers/HomeController.cs
├── Models/
├── Views/
│   ├── Home/          # Index, About, Contact, Privacy
│   └── Shared/        # Layout, partials
└── wwwroot/
    ├── css/site.css   # Modern dark luxury theme
    └── js/site.js     # Animations & interactions
```
