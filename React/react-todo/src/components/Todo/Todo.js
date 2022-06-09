import React from 'react';
import PropTypes from 'prop-types';
import styles from './Todo.module.css';

const Todo = (props) => {

  return(
    <li key={props.todo.key}><span>{props.todo.text}</span> <button className={styles.deletebtn} onClick={() => props.delete(props.todo.key)}>delete</button></li>
  );
};

Todo.propTypes = {};

Todo.defaultProps = {};

export default Todo;
