FROM ubuntu:22.04
ENV DEBIAN_FRONTEND=noninteractive
EXPOSE 7777

WORKDIR /game
RUN apt-get update && apt-get upgrade -y
COPY Builds/GameServer/ /game/
RUN chmod +x /game/game.x86_64
CMD ["/game/game.x86_64"]
