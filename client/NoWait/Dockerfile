FROM node:18.13-alpine AS build

WORKDIR /app

COPY package*.json .

RUN npm ci 

COPY . .

RUN npm run build

FROM nginx:alpine3.18 AS run

WORKDIR /usr/share/nginx/html

COPY --from=build /app/dist/no-wait/browser .

EXPOSE 80

CMD [ "nginx","-g","daemon off;" ]

