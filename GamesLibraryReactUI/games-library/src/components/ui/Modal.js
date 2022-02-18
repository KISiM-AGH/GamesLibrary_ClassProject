import classes from './Modal.module.css';

function Modal(props) {
  return <div className={classes.modal}>
    <h2>{props.title}</h2>
    <p>{props.text}</p>
    { props.button ? <div className={classes.actions}>
      <button onClick={props.onClose}>Ok</button>
    </div> : <div/>}
  </div>
}

export default Modal;