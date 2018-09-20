using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskBoardAssistant.Common.Models;
using TaskBoardAssistant.Common.Services;

namespace UnitTests
{
    [TestClass]
    public class TestPolicy
    {
        public const string PolicyDirPath = "../../TestPolicies/";
        public const string ArchiveDoneJson = PolicyDirPath + "ArchiveDone.json";
        public const string ArchiveDoneYml = PolicyDirPath + "ArchiveDone.yml";

        [TestMethod]
        public void PolicyEquals()
        {
            Policy p1 = new Policy
            {
                Name = "archive-done",
                Resource = ResourceType.List,
                Filters = new List<TaskBoardResourceFilter>
                {
                    new TaskBoardResourceFilter
                    {
                        Name = "done"
                    }
                },
                Children = new List<Policy>
                {
                    new Policy
                    {
                        Resource = ResourceType.Card,
                        Actions = new List<BaseAction>
                        {
                            new BaseAction
                            {
                                Type = ResourceAction.Archive
                            }
                        }
                    }
                }
            };

            Policy p2 = new Policy
            {
                Name = "archive-done",
                Resource = ResourceType.List,
                Filters = new List<TaskBoardResourceFilter>
                {
                    new TaskBoardResourceFilter
                    {
                        Name = "done"
                    }
                },
                Children = new List<Policy>
                {
                    new Policy
                    {
                        Resource = ResourceType.Card,
                        Actions = new List<BaseAction>
                        {
                            new BaseAction
                            {
                                Type = ResourceAction.Archive
                            }
                        }
                    }
                }
            };

            Assert.IsTrue(p1.Equals(p2));

            p1 = new Policy();
            p2 = new Policy();
            Assert.IsTrue(p1.Equals(p2));
        }

        [TestMethod]
        public void PolicyNotEqual()
        {
            Policy p1 = new Policy
            {
                Name = "archive-done",
                Resource = ResourceType.List,
                Filters = new List<TaskBoardResourceFilter>
                {
                    new TaskBoardResourceFilter
                    {
                        Name = "done"
                    }
                },
                Children = new List<Policy>
                {
                    new Policy
                    {
                        Resource = ResourceType.Card,
                        Actions = new List<BaseAction>
                        {
                            new BaseAction
                            {
                                Type = ResourceAction.Archive
                            }
                        }
                    }
                }
            };

            Policy p2 = new Policy
            {
                Name = "archive-not-done",
                Resource = ResourceType.List,
                Filters = new List<TaskBoardResourceFilter>
                {
                    new TaskBoardResourceFilter
                    {
                        Name = "done"
                    }
                },
                Children = new List<Policy>
                {
                    new Policy
                    {
                        Resource = ResourceType.Card,
                        Actions = new List<BaseAction>
                        {
                            new BaseAction
                            {
                                Type = ResourceAction.Archive
                            }
                        }
                    }
                }
            };
            Assert.IsFalse(p1.Equals(p2));
        }

        [TestMethod]
        public void LoadJsonFromString()
        {
            Policy p1 = new Policy
            {
                Name = "archive-done",
                Resource = ResourceType.Board,
                Filters = new List<TaskBoardResourceFilter>
                {
                    new TaskBoardResourceFilter
                    {
                        Name = "personal"
                    }
                },
                Children = new List<Policy>
                {
                    new Policy
                    {
                        Resource = ResourceType.List,
                        Filters = new List<TaskBoardResourceFilter>
                        {
                            new TaskBoardResourceFilter
                            {
                                Name = "done"
                            }
                        },
                        Children = new List<Policy>
                        {
                            new Policy
                            {
                                Resource = ResourceType.Card,
                                Actions = new List<BaseAction>
                                {
                                    new BaseAction
                                    {
                                        Type = ResourceAction.Archive
                                    }
                                }
                            }
                        }
                    }
                }
            };

            string policy =
                @"
              {
                ""Provider"": ""trello"",
                ""Policies"": [
                  {
                    ""Name"": ""archive-done"",
                    ""Resource"": ""board"",
                    ""Filters"": [
                      {
                        ""Name"": ""personal""
                      }
                    ],
                    ""Children"": [
                      {
                        ""Resource"": ""list"",
                        ""Filters"": [
                          {
                            ""Name"": ""done""
                          }
                        ],
                        ""Children"": [
                          {
                            ""Resource"": ""card"",
                            ""Actions"": [
                              {
                                ""Type"": ""archive""
                              }
                            ]
                          }
                        ]
                      }
                    ]
                  }
                ]
             }
                ";
            var collection = PolicyService.JsonFromString(policy);
            Assert.IsTrue(collection.Policies.Count == 1);
            Assert.IsTrue(collection.Policies[0].Equals(p1));
        }

        [TestMethod]
        public void LoadJsonFromFile()
        {

            Policy p1 = new Policy
            {
                Name = "archive-cards-in-done",
                Resource = ResourceType.Board,
                Filters = new List<TaskBoardResourceFilter>
                {
                    new TaskBoardResourceFilter
                    {
                        Name = "personal"
                    }
                },
                Children = new List<Policy>
                {
                    new Policy
                    {
                        Resource = ResourceType.List,
                        Filters = new List<TaskBoardResourceFilter>
                        {
                            new TaskBoardResourceFilter
                            {
                                Name = "done"
                            }
                        },
                        Children = new List<Policy>
                        {
                            new Policy
                            {
                                Resource = ResourceType.Card,
                                Actions = new List<BaseAction>
                                {
                                    new BaseAction
                                    {
                                        Type = ResourceAction.Archive
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var collection = PolicyService.JsonFromFile(ArchiveDoneJson);
            Assert.IsTrue(collection.Policies.Count == 1);
            Assert.IsTrue(collection.Policies[0].Equals(p1));
        }

        [TestMethod]
        public void LoadYmlFromFile()
        {
            Policy p1 = new Policy
            {
                Name = "archive-cards-in-done",
                Resource = ResourceType.Board,
                Filters = new List<TaskBoardResourceFilter>
                {
                    new TaskBoardResourceFilter
                    {
                        Name = "personal"
                    }
                },
                Children = new List<Policy>
                {
                    new Policy
                    {
                        Name = "archive-done",
                        Resource = ResourceType.List,
                        Filters = new List<TaskBoardResourceFilter>
                        {
                            new TaskBoardResourceFilter
                            {
                                Name = "done"
                            }
                        },
                        Children = new List<Policy>
                        {
                            new Policy
                            {
                                Resource = ResourceType.Card,
                                Actions = new List<BaseAction>
                                {
                                    new BaseAction
                                    {
                                        Type = ResourceAction.Archive
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var collection = PolicyService.YmlFromFile(ArchiveDoneYml);
            Assert.IsTrue(collection.Policies.Count == 1);
            Assert.IsTrue(collection.Policies[0].Equals(p1));
        }

        [TestMethod]
        public void LoadYmlFromString()
        {
            Policy p1 = new Policy
            {
                Name = "archive-cards-in-done",
                Resource = ResourceType.Board,
                Filters = new List<TaskBoardResourceFilter>
                {
                    new TaskBoardResourceFilter
                    {
                        Name = "personal"
                    }
                },
                Children = new List<Policy>
                {
                    new Policy
                    {
                        Name = "archive-done",
                        Resource = ResourceType.List,
                        Filters = new List<TaskBoardResourceFilter>
                        {
                            new TaskBoardResourceFilter
                            {
                                Name = "done"
                            }
                        },
                        Children = new List<Policy>
                        {
                            new Policy
                            {
                                Resource = ResourceType.Card,
                                Actions = new List<BaseAction>
                                {
                                    new BaseAction
                                    {
                                        Type = ResourceAction.Archive
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var collection = PolicyService.YmlFromString(@"
              provider: trello
              policies:
                - name: archive-cards-in-done
                  resource: board
                  filters:
                    - name: personal
                  children:
                    - resource: list
                      filters:
                        - name: done
                      children:
                        - resource: card
                          actions:
                            - type: archive       
            ");
            Assert.IsTrue(collection.Policies.Count == 1);
            Assert.IsTrue(collection.Policies[0].Equals(p1));
        }

        [TestMethod]
        public void JsonEqualsYml()
        {
            var jsonCollection = PolicyService.JsonFromFile(PolicyDirPath + "ArchiveDone.json");
            var ymlCollection = PolicyService.YmlFromFile(PolicyDirPath + "ArchiveDone.yml");
            Assert.IsTrue(jsonCollection.Policies.Count == ymlCollection.Policies.Count && jsonCollection.Policies.Count == 1);
            Assert.IsTrue(jsonCollection.Policies[0].Equals(ymlCollection.Policies[0]));
        }
    }
}
