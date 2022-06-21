import React from "react";
import "./Input.css";
import Todo from "../Todo/Todo";

class Input extends React.Component {
  constructor(props) {
    super(props);
    this.state = { todos: [], todo: "" };

    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleChange = this.handleChange.bind(this);
    const todoList = this.state.todos;
  }

  render() {
    return (
      <div className="Input">
        <form onSubmit={this.handleSubmit}>
          <label>Add todo</label>
          <input onChange={this.handleChange} value={this.state.todo}></input>
          <button>Add</button>
        </form>
        <ul>
          {this.todoList.map((todo, index) => (
            <Todo removeTodo={this.handleDelete} key={index} item={todo} id={index} />
          ))}
        </ul>
      </div>
    );
  }

  handleChange(event) {
    this.setState({ todo: event.target.value });
  }

  handleSubmit(e) {
    e.preventDefault();
    const newTodos = this.state.todos.push(this.state.todo);

    this.setState((state) => ({
      todos: newTodos,
      todo: "",
    }));
  }


  handleDelete(id) {
    // debugger;
    // console.log(this.state.todos);
    // let todoList = this.state.todos;
    // var temp = this.props.todos.filter((a) => a !== todo);
    // this.setState({ todos: temp });
    // const newTodos = [...this.state.todos];
    // newTodos.splice(id, 1);
    // this.setState({
    //     todos: newTodos
    // })
  }
}

export default Input;
