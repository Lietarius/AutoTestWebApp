FROM jetbrains/teamcity-agent

USER root

RUN apt-get update && apt-get install -y \
    curl \
    gnupg \
    npm

USER buildagent