# Demo.API

### How to run
docker build -t demo-api -f Dockerfile . <br>
docker run -p 9091:9091 demo-api

### Swagger
http://localhost:9091/openapi/openapi.json

## Architecture decisions
I used clean architecture pattern and I decided to go with CQRS pattern, other option would be service + repository. Imo data extractions like is a good fit for query handlers.

## TODO
I planned to go with postgres as a db but had not enought time. I would use postgres docker image + docker compose (+ volumes).
