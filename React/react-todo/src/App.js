import logo from './logo.svg';
import './App.css';
import AddTodo from './components/AddTodo/AddTodo';
import Todo from './components/Todo/Todo';
import { useState } from 'react';

function App() {
  // const [todo, setTodo] = useState({currentItem :{text: '', key:''}});
  const [list, setTodos] = useState({todos :[]});

  // const handleInput = e => {
  //   const itemText = e.target.value
  //   const item = { text: itemText, key: Date.now() }
  //   setTodo({
  //     currentItem: item,
  //   })
  // };

  // const addItem = e => {
  //   e.preventDefault()
  //   const newItem = todo.currentItem
  //   if (newItem.text !== '') {
  //     console.log(newItem)
  //     console.log(list)
  //     setTodos( prevState => ({
  //       todos: [...prevState.todos, newItem]
  //     }))
  //     setTodo({
  //       currentItem: {text: '', key: ''}
  //     })
  //   }
  // }
  const addItem = (todo) => {
    debugger
    const newItem = todo
    if (newItem.text !== '') {
      console.log(newItem)
      console.log(list)
      setTodos( prevState => ({
        todos: [...prevState.todos, newItem]
      }))
    }
  }

  const deleteTodo = (id) => {
    debugger
    console.log(id);
    setTodos( prevState => ({
      todos: prevState.todos.filter(item => item.key !== id)
    }))
  }

  return (
    <div className="App">
      <AddTodo addTask={addItem}/>
      <h1>Todos</h1>
      <ul className="todo-list">
        {list.todos.map( i =>
          <Todo key={i.key} todo={i} delete={deleteTodo}/>
          // <li key={i.key}><span>{i.text}</span> <button onClick={() => deleteTodo(i.key)}>delete</button></li>
        )}
      </ul>
    </div>
  );
}

export default App;
