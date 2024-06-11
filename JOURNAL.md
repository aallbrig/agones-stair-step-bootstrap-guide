## June 10th 2024
Sought guidance on how to use Agones. Had these three guides highlighted to me:
- https://agones.dev/site/docs/guides/client-sdks/local/
- https://agones.dev/site/docs/guides/local-game-server/
- https://agones.dev/site/docs/installation/creating-cluster/minikube/

I asked about the devx of how to bootstrap in what I call a "stair step" way. Basically, instead of even worrying about doing stuff inside kubernetes we use a software program that simulates the Agones platform. This is a practical solution that enables rapid development. Nice.

I like using xoofx/UnityNuGet. I noticed there wasn't the AgonesSDK in the registry. I open [issue #375](https://github.com/xoofx/UnityNuGet/issues/375) on the project before submitting [PR #376](https://github.com/xoofx/UnityNuGet/pull/376) to add Agones [C# Game Server Client SDK](https://agones.dev/site/docs/guides/client-sdks/csharp/) to the UnityNuGet registry. Always feels good to contribute to open source.

