﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue 
{
    private ArrayList nodes = new ArrayList();

    public int Length
    {
        get
        {
            return this.nodes.Count;
        }
    }

    public bool Contains(object node)
    {
        return this.nodes.Contains(node);
    }

    public Node First()//첫번쨰 노드를 가져온다
    {
        if(this.nodes.Count >0 )
        {
            return (Node)this.nodes[0];
        }
        return null;
    }
            
    public void Push(Node node)//
    {
        this.nodes.Add(node);
        this.nodes.Sort();
    }

    public void Remove(Node node)
    {
        this.nodes.Remove(node);
        this.nodes.Sort();
    }
}
