# Multi-Language Sample Page

A beautiful, responsive multi-language sample page that automatically detects language preferences from the `X-site-language` header.

## Supported Languages

- 🇺🇸 English (en)
- 🇪🇸 Spanish (es) 
- 🇫🇷 French (fr)
- 🇩🇪 German (de)
- 🇺🇦 Ukrainian (uk)

## Features

- **Automatic Language Detection**: Responds to `X-site-language` HTTP header
- **Manual Language Switching**: Interactive language selector buttons
- **Responsive Design**: Works perfectly on all devices
- **Modern UI**: Beautiful gradient design with glass-morphism effects
- **Keyboard Shortcuts**: Alt+1/2/3/4/5 for quick language switching
- **Fallback Support**: Gracefully falls back to English if requested language is unavailable

## Docker Setup

### Quick Start

1. **Build and run with Docker Compose:**
   ```bash
   docker-compose up --build
   ```

2. **Access the application:**
   - Open your browser and go to `http://localhost:8080`

### Manual Docker Commands

1. **Build the image:**
   ```bash
   docker build -t multi-lang-sample .
   ```

2. **Run the container:**
   ```bash
   docker run -d -p 8080:80 --name multi-lang-sample multi-lang-sample
   ```

3. **Stop the container:**
   ```bash
   docker stop multi-lang-sample
   docker rm multi-lang-sample
   ```

## Testing Language Detection

### Method 1: URL Parameters
Add language parameter to the URL:
- English: `http://localhost:8080?lang=en`
- Spanish: `http://localhost:8080?lang=es`
- French: `http://localhost:8080?lang=fr`
- German: `http://localhost:8080?lang=de`
- Ukrainian: `http://localhost:8080?lang=uk`

### Method 2: HTTP Headers (Server-side)
In a real application, set the `X-site-language` header:
```bash
curl -H "X-site-language: es" http://localhost:8080
```

### Method 3: Manual Switching
Use the language selector buttons on the page.

### Method 4: Keyboard Shortcuts
- Alt+1: English
- Alt+2: Spanish  
- Alt+3: French
- Alt+4: German
- Alt+5: Ukrainian

## Docker Configuration

The Dockerfile includes:
- **Base Image**: nginx:alpine (lightweight and secure)
- **Gzip Compression**: Enabled for better performance
- **Security Headers**: X-Frame-Options, X-Content-Type-Options, etc.
- **Caching**: Static assets cached for 1 year, HTML files not cached
- **Health Check**: Built-in health monitoring
- **Port**: Exposes port 80 (mapped to 8080 on host)

## File Structure

```
maintenance-sample/
├── frontend/
│   └── index.html          # Multi-language sample page
├── Dockerfile              # Docker configuration
├── docker-compose.yml      # Docker Compose configuration
├── .dockerignore          # Docker ignore file
└── README.md              # This file
```

## Customization

To add more languages:
1. Add translations to the `languages` object in `index.html`
2. Add a language button to the switcher
3. Update keyboard shortcuts
4. Update instruction text in all languages

## Production Considerations

For production deployment:
- Use HTTPS (configure SSL certificates)
- Set up proper domain names
- Configure reverse proxy if needed
- Implement proper logging
- Set up monitoring and alerting
