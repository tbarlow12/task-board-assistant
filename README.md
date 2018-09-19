# task-board-assistant
Policy engine for managing task board technologies (Trello, Jira, Planner, etc.)

## Trello Set Up

You'll need a `secrets.json` file in the **root directory of this repo** 
for the tests to run properly:

```
{
  "TRELLO_APP_KEY": "",
  "TRELLO_USER_TOKEN": ""
}
```

To populate this file, you'll need to generate an [app key](https://trello.com/app-key/)
and a [user token](https://trello.com/1/authorize?expiration=never&scope=read,write,account&response_type=token&name=Server%20Token&key=fff37eb4d5dc0d32cb123cc06f88b032).

You'll need to be signed in to your Trello account and grant access for the keys.

From there, the tests should run fine (at least the ones that are passing at the moment).
The test scenarios do depend on some specifically named resources in order to actually
interact with your boards, so feel free to look at `TaskBoardAssistant/UnitTests/TestPolicies` for those details