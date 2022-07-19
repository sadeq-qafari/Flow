# develop stage
FROM node:12-alpine as develop-stage
WORKDIR /app
COPY panel/package*.json ./
RUN npm i -g @quasar/cli
COPY panel .
# build stage
FROM develop-stage as build-stage
RUN npm i
RUN quasar build
# production stage
FROM nginx:1.15 as production-stage
COPY --from=build-stage /app/dist/spa /usr/share/nginx/html
EXPOSE 4200
CMD ["nginx", "-g", "daemon off;"]
