import React from "react";
import Delete from "../Delete/Delete";
import "./Todo.css";

class Todo extends React.Component {
  remove(id) {
    console.log(id, "in todo.js");
    this.props.removeTodo(id);
  }

  render() {
    return (
      <li>
        <span>{this.props.item}</span>
        <Delete deleteTodo={() => this.remove(this.props.id)} />
      </li>
    );
  }
}

export default Todo;
