import React, { useState } from 'react';
import PropTypes from 'prop-types';
import styles from './AddTodo.module.css';

const AddTodo = (props) => {
  const [todo, setTodo] = useState({currentItem :{text: '', key:''}});

  const addTodo = e => {
    e.preventDefault();
    props.addTask(todo.currentItem);
    resetCurrentItem();
  }

  const resetCurrentItem = () => {
    setTodo({
      currentItem: {text: '', key:''},
    })
  }

  const changeInput = e => {
    const itemText = e.target.value
    const item = { text: itemText, key: Date.now() }
    setTodo({
      currentItem: item,
    })
  }


  return(
    <div className={styles.AddTodo}>
      <form className={styles.form} onSubmit={addTodo}>
        <input
          className={styles.inpt}
          placeholder="Task"
          value={todo.currentItem.text}
          onChange={changeInput}
        />
        <button className={styles.btn} type="submit"> Add Task </button>
      </form>
    </div>
  );
};

const handleInput = e => {
  const itemText = e.target.value
  const currentItem = { text: itemText, key: Date.now() }
  this.setState({
    currentItem,
  })
}

const addItem = e => {
  e.preventDefault()
  const newItem = this.state.currentItem
  // if (newItem.text !== '') {
  //   console.log(newItem)
  //   const items = [...this.state.items, newItem]
  //   this.setState({
  //     items: items,
  //     currentItem: { text: '', key: '' },
  //   })
  // }

  this.props.add(newItem);
}



AddTodo.propTypes = {};

AddTodo.defaultProps = {};

export default AddTodo;
