# Demo.API

### How to run
docker build -t demo-api -f Dockerfile . <br>
docker run -p 9091:9091 demo-api

### Swagger
http://localhost:9091/openapi/openapi.json

### Improvements
- For persistence I would use postgres image + docker compose (with volumes).
- Validations could be improved using FluentValidation.
