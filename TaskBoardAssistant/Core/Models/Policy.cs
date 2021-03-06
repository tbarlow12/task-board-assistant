﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskBoardAssistant.Core.Models
{
    public class Policy
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public ResourceType Resource { get; set; }
        public Dictionary<string, string> Query { get; set; }
        public List<TaskBoardResourceFilter> Filters { get; set; }
        public List<BaseAction> Actions { get; set; }
        public List<Policy> Children { get; set; }
        public override bool Equals(Object o)
        {
            var other = (Policy)o;
            var nameEquals = (Name == null && other.Name == null) ||
                (Name != null && other.Name != null && Name.Equals(other.Name));
            var resourceEquals = Resource.Equals(other.Resource);
            var queryEquals = (Query == null && other.Query == null) ||
                (Query != null && other.Query != null && Query.Equals(other.Query));
            var filterEquals = ((Filters == null && other.Filters == null) || 
                (Filters.SequenceEqual(other.Filters)));
            var actionEquals = (Actions == null && other.Actions == null) || 
                (Actions.SequenceEqual(other.Actions));
            return nameEquals && resourceEquals && queryEquals && filterEquals && actionEquals;      
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public enum TaskBoardService
    {
        Trello,
        Github,
        AzDO
    }

    public enum ResourceType
    {
        // Trello
        Team,
        Board,
        List,
        Member,
        Card,
        Label,
        // Github
        Repo,
        Project,
        Issue,
        // AzDO
        WorkItem,
        Bug,
        Story
    }   
}
