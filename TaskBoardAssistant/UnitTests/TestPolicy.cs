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
                @"[
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
                ";
            var policies = PolicyService.JsonFromString(policy);
            Assert.IsTrue(policies.Count == 1);
            Assert.IsTrue(policies[0].Equals(p1));
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
            var policies = PolicyService.JsonFromFile(ArchiveDoneJson);
            Assert.IsTrue(policies.Count == 1);
            Assert.IsTrue(policies[0].Equals(p1));
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
            var policies = PolicyService.YmlFromFile(ArchiveDoneYml);
            Assert.IsTrue(policies.Count == 1);
            Assert.IsTrue(policies[0].Equals(p1));
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
            var policies = PolicyService.YmlFromString(@"
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
            Assert.IsTrue(policies.Count == 1);
            Assert.IsTrue(policies[0].Equals(p1));
        }

        [TestMethod]
        public void JsonEqualsYml()
        {
            var jsonPolicies = PolicyService.JsonFromFile(PolicyDirPath + "ArchiveDone.json");
            var ymlPolicies = PolicyService.YmlFromFile(PolicyDirPath + "ArchiveDone.yml");
            Assert.IsTrue(jsonPolicies.Count == ymlPolicies.Count && jsonPolicies.Count == 1);
            Assert.IsTrue(jsonPolicies[0].Equals(ymlPolicies[0]));
        }
    }
}
