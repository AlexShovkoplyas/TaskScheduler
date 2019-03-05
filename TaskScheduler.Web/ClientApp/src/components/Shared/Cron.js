import React from 'react';
// import InputGroup from 'react-bootstrap/InputGroup';
import { Alert } from 'react-bootstrap';
// import FormControl from 'react-bootstrap/FormControl';
// import { InputGroup,  FormControl } from 'react-bootstrap';
// import {Form, Row } from 'react-bootstrap';
// import {FormControl } from 'react-bootstrap';

const Cron = (props) => (
    [
        'primary',
        'secondary',
        'success',
        'danger',
        'warning',
        'info',
        'light',
        'dark',
      ].map((variant, idx) => (
        <Alert key={idx} variant={variant}>
          This is a {variant} alert with{' '}
          <Alert.Link href="#">an example link</Alert.Link>. Give it a click if you
          like.
        </Alert>
      ))

//     <div>
//   <InputGroup size="sm" className="mb-3">
//     <InputGroup.Prepend>
//       <InputGroup.Text id="inputGroup-sizing-sm">Small</InputGroup.Text>
//     </InputGroup.Prepend>
//     <FormControl aria-label="Small" aria-describedby="inputGroup-sizing-sm" />
//   </InputGroup>
//   <br />
//   <InputGroup className="mb-3">
//     <InputGroup.Prepend>
//       <InputGroup.Text id="inputGroup-sizing-default">Default</InputGroup.Text>
//     </InputGroup.Prepend>
//     <FormControl
//       aria-label="Default"
//       aria-describedby="inputGroup-sizing-default"
//     />
//   </InputGroup>
//   <br />
//   <InputGroup size="lg">
//     <InputGroup.Prepend>
//       <InputGroup.Text id="inputGroup-sizing-lg">Large</InputGroup.Text>
//     </InputGroup.Prepend>
//     <FormControl aria-label="Large" aria-describedby="inputGroup-sizing-sm" />
//   </InputGroup>
// </div>
);


export default Cron;
