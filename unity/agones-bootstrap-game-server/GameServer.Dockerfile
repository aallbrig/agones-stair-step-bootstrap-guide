FROM ubuntu:22.04
ENV DEBIAN_FRONTEND=noninteractive

EXPOSE 7777/tcp
EXPOSE 7777/udp

RUN apt-get update && apt-get upgrade -y && apt-get install \
    lsof \
    net-tools

RUN groupadd gameserver && \
    useradd -r -g gameserver -d /home/gameserver -s /bin/bash -c "Game Server User" gameserver && \
    mkdir -p /home/gameserver
RUN chown gameserver:gameserver /home/gameserver
USER gameserver
WORKDIR /home/gameserver
COPY Builds/GameServer/ /home/gameserver/GameServer
ENTRYPOINT ["/home/gameserver/GameServer/game.x86_64"]
