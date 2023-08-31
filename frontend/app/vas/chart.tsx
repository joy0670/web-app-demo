'use client';

import { Card, AreaChart, Title, Text } from '@tremor/react';

const data = [
  {
    Hour: '6-1',
    Actual: 2890,
    //Profit: 2400
  },
  {
    Hour: '6-2',
    Actual: 2890,
    //Profit: 2400
  },
  {
    Hour: '6-3',
    Actual: 2890,
    //Profit: 2400
  },
  {
    Hour: '6-4',
    Actual: 2890,
    //Profit: 2400
  },
  {
    Hour: '7',
    Actual: 1890,
    //Profit: 1398
  },
  {
    Hour: '8',
    Actual: 1398,
    //Profit: 1398
  },
  {
    Hour: '9',
    Actual: 2698,
    //Profit: 1398
  },
  {
    Hour: '10',
    Actual: 6985,
    //Profit: 1398
  },
  {
    Hour: '11',
    Actual: 789,
  },
  {
    Hour: '12',
    Actual: 789,
  },
  {
    Hour: '13',
    Actual: 789,
  },
  {
    Hour: '14',
    Actual: 789,
  },
  {
    Hour: '15',
    Actual: 789,
  },
  {
    Hour: '16',
    Actual: 789,
  },

];

export default function Example() {
  return (
    <Card>
      <Title>Performance</Title>
      <Text>Output per hour</Text>
      <AreaChart
        className="mt-4 h-80"
        data={data}
        categories={['Actual', 'Plan']}
        index="Hour"
        colors={['indigo', 'fuchsia']}
        valueFormatter={(number: number) =>
          //`$ ${Intl.NumberFormat('us').format(number).toString()}`
          `$ ${Intl.NumberFormat('us').format(number).toString()}`
        }
        yAxisWidth={60}
      />
    </Card>
  );
}
