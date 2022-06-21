import React from 'react';
import './Delete.css';

class Delete extends React.Component {

  constructor(props) {
    super(props)
    this.state = {item : ''};
  }

    onDelete = () => {
      this.props.deleteTodo()
    }

    render() {
      return (
        <button onClick={this.onDelete}>Del</button>
      );
    }
}

export default Delete;
