import React, { Component } from 'react';

export default class SimpleComponent extends React.Component<any, { count: number }> {
    constructor(props:any) {
        super(props);
        
        this.state = {
            count: 0,
        }
        
    }
    
    render () {
        return (<div>
            <h3>This is simple react component</h3>
            <div>
                <span className={"counterState"}>Counter state is {this.state.count}</span>
                <button onClick={()=>{this.handleIncrement()}}>+1</button>
                <button onClick={()=>{this.handleDecrement()}}>-1</button>
            </div>
        </div>);
    }

    handleIncrement() {
        this.setState({
            count: this.state.count +1
        })
    }

    handleDecrement() {
        this.setState({
            count: this.state.count -1
        })
    }
}